using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "User Data All", menuName = "data/userData", order = 1)]
public class UserData : ScriptableObject
{
    public List<User> alldata;
}

[Serializable]
public class User
{
    public int id;
    public string name;
    public string username;
    public string email;
    public Address address;
    public string phone;
    public string website;
    public Company company;
}

[Serializable]
public class Address
{
    public string street;
    public string suite;
    public string city;
    public string zipcode;
    public Geology geo;
}

[Serializable]
public class Geology
{
    public string lat;
    public string lng;
}

public class Company
{
    public string name;
    public string catchPhrase;
    public string bs;
}
