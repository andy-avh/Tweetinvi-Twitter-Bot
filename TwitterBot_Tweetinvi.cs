using System;
using System.IO; // this allows us to use files on our computer
using Tweetinvi; // allows us to access Twitter class
using Tweetinvi.Models; //
using System.Threading.Tasks;
using Tweetinvi.Parameters; // allows us to push custom paramters (image) into ITweet
using HtmlAgilityPack; // access htmlAgilityPack class

// made following: https://www.youtube.com/watch?v=aOlp3vXohB0&ab_channel=BearTheCoder

namespace TwitterBot
{
    class Program
    {
        static async Task Main(string[] args) // converted main function into Task to use await
        {
            string APIKey = "";                                        // add APIkey from twitter developer app
            string APISecret = "";            // and the rest
            string AccessToken = "";          //  "
            string AccessSecret = "";              //  "

            TwitterClient UserClient = new TwitterClient(APIKey, APISecret, AccessToken, AccessSecret);
            // instantiate a new TwitterClient, feed it our app authorisation details
            byte[] ImageBytes = File.ReadAllBytes("churchill.jpg"); // making an array to store the byte content of our image
            IMedia ImageIMedia = await UserClient.Upload.UploadTweetImageAsync(ImageBytes);

            ITweet TweetWithImage = await UserClient.Tweets.PublishTweetAsync(new PublishTweetParameters ("#churchill") { Medias = { ImageIMedia } } );
            // ^^^ this is what will actually tweet, press f12 on PublishTweetParameters to access source code
            // put text into brackets on PublishTweetParameters() to add text -  we have tweeted #churchill
            // { Medias = { ImageIMedia } } is the image being tweeted, in a list. check source code as to why
            // (" ") < stuff in speech marks is text being tweeteed above the image

            // TO GET PROGRAM TO RUN AUTOMATICALLY
            // win+r
            // type: shell:startup
            // inside the opened folder, add shortcut of the exe to the startup folder
            // 

        }
    }
}
