using System;
using System.Collections.Generic;

class SocialMediaPlatform
{
    static void Main()
    {
        // List to store posts
        List<string> posts = new List<string>();

        // Dictionary to track likes per post
        Dictionary<string, int> likes = new Dictionary<string, int>();

        // HashSet to store unique user IDs
        HashSet<int> userIds = new HashSet<int>();

        // Stack to track recent actions (Undo feature)
        Stack<string> recentActions = new Stack<string>();

        // Queue to process notifications
        Queue<string> notifications = new Queue<string>();

        // Adding unique users
        userIds.Add(101);
        userIds.Add(102);
        userIds.Add(103);
        userIds.Add(101); // Duplicate, won't be added

        // Adding posts
        posts.Add("First Post");
        posts.Add("Second Post");

        // Initializing likes
        likes["First Post"] = 10;
        likes["Second Post"] = 5;

        // Tracking actions
        recentActions.Push("User 101 liked First Post");
        recentActions.Push("User 102 commented on Second Post");
        recentActions.Push("User 103 shared First Post");

        // Adding notifications
        notifications.Enqueue("New like on First Post");
        notifications.Enqueue("New comment on Second Post");
        notifications.Enqueue("New share on First Post");

        // Display Unique Users
        Console.WriteLine("Unique User IDs:");
        foreach (int id in userIds)
        {
            Console.WriteLine(id);
        }

        // Display Posts and Likes
        Console.WriteLine("\nPosts and Likes:");
        foreach (string post in posts)
        {
            Console.WriteLine(post + " - Likes: " + likes[post]);
        }

        // Undo Last Action
        Console.WriteLine("\nUndo Last Action:");
        if (recentActions.Count > 0)
        {
            Console.WriteLine("Removed Action: " + recentActions.Pop());
        }

        // Process Notifications
        Console.WriteLine("\nProcessing Notifications:");
        while (notifications.Count > 0)
        {
            Console.WriteLine(notifications.Dequeue());
        }
    }
}
