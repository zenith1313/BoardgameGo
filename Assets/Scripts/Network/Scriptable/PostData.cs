using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Post Data All", menuName = "data/postData", order = 1)]
public class PostData : ScriptableObject
{
    public List<Post> alldata;
}

[Serializable]
public class Post
{
    public int userId;
    public int id;
    public string title;
    public string body;
}
