// Video.cs
using System;
using System.Collections.Generic;

public class Video
{
    // Attributes
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments; // List to store Comment objects

    // Constructor
    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>(); // Initialize the list
    }

    // Methods
    public void AddComment(Comment newComment)
    {
        _comments.Add(newComment);
    }

    // Overload to create and add comment directly
    public void AddComment(string commenterName, string commentText)
    {
        Comment newComment = new Comment(commenterName, commentText);
        _comments.Add(newComment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Getters for Video properties
    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public int GetLengthInSeconds()
    {
        return _lengthInSeconds;
    }

    // Method to display all video details including comments
    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_lengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");

        if (GetNumberOfComments() > 0)
        {
            Console.WriteLine("Comments:");
            foreach (Comment comment in _comments)
            {
                // Using getters from Comment class
                Console.WriteLine($"  - {comment.GetCommenterName()}: \"{comment.GetCommentText()}\"");
            }
        }
        else
        {
            Console.WriteLine("  (No comments yet)");
        }
        Console.WriteLine("-----------------------------------"); // Separator
    }

    // Optional: Getter for the comments list if needed by external logic
    // public List<Comment> GetAllComments()
    // {
    //     return _comments;
    // }
}