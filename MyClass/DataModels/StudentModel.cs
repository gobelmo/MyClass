using System;
using Google.Cloud.Firestore;

namespace MyClass.DataModels;
[FirestoreData]
public class StudentModel
{
    [FirestoreProperty]
    public int No { get; set; }
    [FirestoreProperty]
    public string Id { get; set; }
    [FirestoreProperty]
    public string FullName { get; set; }
    [FirestoreProperty]
    public string GoogleName { get; set; }
    [FirestoreProperty]
    public int GroupNo { get; set; }
    public string AvatarUrl { get; set; }
    
    // Attendance properties
    [FirestoreProperty]
    public string Attn02Sep { get; set; }
    [FirestoreProperty]
    public string Attn09Sep { get; set; }
    [FirestoreProperty]
    public string Attn16Sep { get; set; }
    [FirestoreProperty]
    public string Attn23Sep { get; set; }
    [FirestoreProperty]
    public string Attn07Oct { get; set; }
    [FirestoreProperty]
    public string Attn21Oct { get; set; }
    [FirestoreProperty]
    public string Attn28Oct { get; set; }
    [FirestoreProperty]
    public string Attn04Nov { get; set; }

    // Assignment properties as strings
    [FirestoreProperty]
    public string Assignment_1 { get; set; }
    [FirestoreProperty]
    public string Assignment_1_link { get; set; }
    [FirestoreProperty]
    public int Assignment_1_score { get; set; }
    [FirestoreProperty]
    public string Assignment_2 { get; set; }
     [FirestoreProperty]
    public int Assignment_2_score { get; set; }
    [FirestoreProperty]
    public string Assignment_2_link { get; set; }
    [FirestoreProperty]
    public string Assignment_3 { get; set; }
    [FirestoreProperty]
    public string Assignment_3_link { get; set; }
     [FirestoreProperty]
    public int Assignment_3_score { get; set; }
    [FirestoreProperty]
    public string Assignment_4 { get; set; }
    [FirestoreProperty]
    public string Assignment_4_link { get; set; }
     [FirestoreProperty]
    public int Assignment_4_score { get; set; }
    [FirestoreProperty]
    public string Assignment_5 { get; set; }
    [FirestoreProperty]
    public string Assignment_5_link { get; set; }
     [FirestoreProperty]
    public int Assignment_5_score { get; set; }
    [FirestoreProperty]
    public string Assignment_6 { get; set; }
    [FirestoreProperty]
    public string Assignment_6_link { get; set; }
     [FirestoreProperty]
    public int Assignment_6_score { get; set; }
    [FirestoreProperty]
    public string Assignment_7 { get; set; }
    [FirestoreProperty]
    public string Assignment_7_link { get; set; }
     [FirestoreProperty]
    public int Assignment_7_score { get; set; }
    [FirestoreProperty]
    public string Assignment_8 { get; set; }
    [FirestoreProperty]
    public string Assignment_8_link { get; set; }
     [FirestoreProperty]
    public int Assignment_8_score { get; set; }
    [FirestoreProperty]
    public string Assignment_9 { get; set; }
    [FirestoreProperty]
    public string Assignment_9_link { get; set; }
     [FirestoreProperty]
    public int Assignment_9_score { get; set; }
    [FirestoreProperty]
    public string Assignment_10 { get; set; }
    [FirestoreProperty]
    public string Assignment_10_link { get; set; }
     [FirestoreProperty]
    public int Assignment_10_score { get; set; }
    [FirestoreProperty]
    public string Assignment_11 { get; set; }
    [FirestoreProperty]
    public string Assignment_11_link { get; set; }
     [FirestoreProperty]
    public int Assignment_11_score { get; set; }
    [FirestoreProperty]
    public string Assignment_12 { get; set; }
    [FirestoreProperty]
    public string Assignment_12_link { get; set; }
     [FirestoreProperty]
    public int Assignment_12_score { get; set; }

    public string AttendanceSummary
    {
        get
        {
            var attendanceDates = new[]
            {
                Attn02Sep, Attn09Sep, Attn16Sep, Attn23Sep, 
                Attn07Oct, Attn21Oct, Attn28Oct, Attn04Nov
            };

            // Count the attended ("/") days
            int attendedCount = attendanceDates.Count(d => d == "/");
            int totalDays = attendanceDates.Length;

            return $"Attandant {attendedCount}/{totalDays}";
        }
    }
}

