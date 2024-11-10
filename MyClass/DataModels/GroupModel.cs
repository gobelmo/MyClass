using System;
using Google.Cloud.Firestore;

namespace MyClass.DataModels;

[FirestoreData]
public class GroupModel
{
    [FirestoreProperty]
    public string Id { get; set; }

    [FirestoreProperty]
    public string AppName { get; set; }

     [FirestoreProperty]
    public string AppDescription { get; set; }

    [FirestoreProperty]
    public string AppIcon { get; set; }

    [FirestoreProperty]
    public string AppScreenLink { get; set; }

    [FirestoreProperty]
    public string GitHubLink { get; set; }
    
     [FirestoreProperty]
    public string ProposalLink { get; set; }


}
