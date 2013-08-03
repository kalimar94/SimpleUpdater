using System;
using System.Net;
using System.Windows;

class Example
{
    static void Main()
    {
        Updater.CheckForUpdatesAsync();

        // Read input
        while (true)
        {
            Console.ReadLine();
        }
    }


}

class Updater
{
    static decimal currentVersion = 1.01m;
    static string versionFile = "https://github.com/kalimar94/SimpleUpdater/SimpleUpdater/version.ver";
    public static void CheckForUpdates()
    {
        try
        {
            // declaring the client in a using scope so that it is automaticly disposed at the end of the scope
            // we don't need to manualy client.Dispose() this way
            using (WebClient client = new WebClient())
            {
                string versionAsString = client.DownloadString(versionFile);
                decimal version = decimal.Parse(versionAsString);
                if (version > currentVersion)
                {
                    Console.WriteLine("There is a new version of the program");
                    Console.WriteLine("Current version: {0}  |  New version: {1}", currentVersion, version);
                    DownloadUpdates();
                }
            }
        }
        catch (Exception theException)
        {
            Console.WriteLine("The updating processed failed due to: {0}", theException.Message);
        }

    }

    // This is an async method it works in the background, it allows your program to continiue while updating is being processed in the background
    public async static void CheckForUpdatesAsync()
    {
        try
        {
            // declaring the client in a using scope so that it is automaticly disposed at the end of the scope
            // we don't need to manualy client.Dispose() this way
            using (WebClient client = new WebClient())
            {
                string versionAsString = await client.DownloadStringTaskAsync(versionFile);
                decimal version = decimal.Parse(versionAsString);
                if (version > currentVersion)
                {
                    Console.WriteLine("There is a new version of the program");
                    Console.WriteLine("Current version: {0}  |  New version: {1}", currentVersion, version);
                    DownloadUpdates();
                }
            }
        }
        catch (Exception theException)
        {
            Console.WriteLine("The updating processed failed due to: {0}", theException.Message);
        }

    }



    static void DownloadUpdates()
    {
        using (WebClient downloader = new WebClient())
        {
           // downloader.DownloadFile("adress", System.IO.Directory.GetCurrentDirectory());  // download a file to the current directory
        }
    }
}
