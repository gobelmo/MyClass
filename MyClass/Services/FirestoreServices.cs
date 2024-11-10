using System;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using MyClass.DataModels;

namespace MyClass.Services;

public class FirestoreService
{
    private FirestoreDb db;
    public string StatusMessage;
    public FirestoreService()
    {
        this.SetupFireStore();
    }
    private async Task SetupFireStore()
    {
        this.StatusMessage = "firestore db connected.";
        try
        {
            if (db == null)
            {
                var stream = await FileSystem.OpenAppPackageFileAsync("myclass-de4b5-firebase-adminsdk-w2b9j-99925feb03.json");
                var reader = new StreamReader(stream);
                var contents = reader.ReadToEnd();
                db = new FirestoreDbBuilder
                {
                    ProjectId = "myclass-de4b5",
                    JsonCredentials = contents
                }.Build();
            }
        }
        catch (Exception exc)
        {
            this.StatusMessage = exc.Message;
            throw;
        }
    }

    public async Task<List<StudentModel>> GetAllStudents()
    {
        this.StatusMessage = "get all students";
        try
        {
            var studentList = new List<StudentModel>();
            var studentsRef = db.Collection("students");
            var snapshot = await studentsRef.GetSnapshotAsync();

            foreach (var document in snapshot.Documents)
            {
                if (document.Exists)
                {
                    StudentModel student = document.ConvertTo<StudentModel>();
                    student.Id = document.Id;
                    studentList.Add(student);
                }
            }

            return studentList;
        }
        catch (Exception exc)
        {
            this.StatusMessage = exc.Message;
            throw;
        }
    }

    public async Task<bool> UpdateStudentAssignments(StudentModel student)
    {
        try
        {
            // Reference to the student document in Firestore
            var studentRef = db.Collection("students").Document(student.Id);

            // Update the assignments in Firestore
            await studentRef.UpdateAsync(new Dictionary<string, object>
                {
                    { "Assignment_1", student.Assignment_1 },
                    { "Assignment_2", student.Assignment_2 },
                    { "Assignment_3", student.Assignment_3 },
                    { "Assignment_4", student.Assignment_4 },
                    { "Assignment_5", student.Assignment_5 },
                    { "Assignment_6", student.Assignment_6 },
                    { "Assignment_7", student.Assignment_7 },
                    { "Assignment_8", student.Assignment_8 },
                    { "Assignment_9", student.Assignment_9 },
                    { "Assignment_10", student.Assignment_10 },
                    { "Assignment_11", student.Assignment_11 },
                    { "Assignment_12", student.Assignment_12 }
                });

            return true; // Success
        }
        catch (Exception ex)
        {
            // Handle error
            this.StatusMessage = ex.Message;
            throw;
        }
    }

    public async Task<List<GroupModel>> GetAllGroups()
    {
        this.StatusMessage = "get all groups";
        try
        {
            var groupList = new List<GroupModel>();
            var groupsRef = db.Collection("groups");
            var snapshot = await groupsRef.GetSnapshotAsync();

            foreach (var document in snapshot.Documents)
            {
                if (document.Exists)
                {
                    GroupModel group = document.ConvertTo<GroupModel>();
                    group.Id = document.Id;
                    groupList.Add(group);
                }
            }

            return groupList;
        }
        catch (Exception exc)
        {
            this.StatusMessage = exc.Message;
            throw;
        }
    }

}
