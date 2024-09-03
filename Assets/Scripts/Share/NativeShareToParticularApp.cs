using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class NativeShareToParticularApp : MonoBehaviour
{

    public Button shareButton;

    private bool isFocus = false;
    private bool isProcessing = false;

    public string packageName = "com.whatsapp";
    private string screenshotName;

    void Start()
    {
        shareButton.onClick.AddListener(ShareText);
        screenshotName = "Dodgers_highscore.png";
    }

    void OnApplicationFocus(bool focus)
    {
        isFocus = focus;
    }

    public void ShareText()
    {

#if UNITY_ANDROID
        if (!isProcessing)
        {

            //check if app installed
            if (CheckIfAppInstalled())
            {
                StartCoroutine(ShareTextInAnroid());
            }
            else
            {
                //fallback plan
                //can either disable the whatsapp share button
                //or can a normal share trigger
            }
        }
#else
		Debug.Log("No sharing set up for this platform.");
#endif
    }

    private bool CheckIfAppInstalled()
    {

#if UNITY_ANDROID

        //create a class reference of unity player activity
        AndroidJavaClass unityActivity =
            new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        //get the context of current activity
        AndroidJavaObject context = unityActivity.GetStatic<AndroidJavaObject>("currentActivity");

        //get package manager reference
        AndroidJavaObject packageManager = context.Call<AndroidJavaObject>("getPackageManager");

        //get the list of all the apps installed on the device
        AndroidJavaObject appsList = packageManager.Call<AndroidJavaObject>("getInstalledPackages", 1);

        //get the size of the list for app installed apps
        int size = appsList.Call<int>("size");

        for (int i = 0; i < size; i++)
        {
            AndroidJavaObject appInfo = appsList.Call<AndroidJavaObject>("get", i);
            string packageNew = appInfo.Get<string>("packageName");

            if (packageNew.CompareTo(packageName) == 0)
            {
                return true;
            }
        }

        return false;

#endif
    }

#if UNITY_ANDROID
    public IEnumerator ShareTextInAnroid()
    {
        // wait for graphics to render
        yield return new WaitForEndOfFrame();
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
        // create the texture
        Texture2D screenTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
        // put buffer into texture
        screenTexture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height), 0, 0);
        // apply
        screenTexture.Apply();
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
        byte[] dataToSave = screenTexture.EncodeToPNG();
        string destination = Path.Combine(Application.persistentDataPath, "ScreenShot.png");
        File.WriteAllBytes(destination, dataToSave);

        isProcessing = true;

        if (!Application.isEditor)
        {
            //Create intent for action send
            AndroidJavaClass intentClass =
                new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject =
                new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>
            ("setAction", intentClass.GetStatic<string>("ACTION_SEND"));

            //create image URI to add it to the intent
            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + destination);

            //put image and string extra
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
            intentObject.Call<AndroidJavaObject>("setType", "image/png");

            //put text and subject extra
            //intentObject.Call<AndroidJavaObject>("setType", "text/plain");
            //intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), shareSubject);
            //intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), shareMessage);

            //set the package to whatsapp package
            intentObject.Call<AndroidJavaObject>("setPackage", packageName);

            //call createChooser method of activity class
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Share your high score");
            currentActivity.Call("startActivity", intentObject);

            yield return new WaitForSecondsRealtime(1);
            yield return new WaitUntil(() => isFocus);
            isProcessing = false;
        }
    }

#endif
}