using System.Data;
using CodeBuddies.Models.Entities;

namespace CodeBuddies.Utils.Functionals
{
    internal class Filters
    {
        static public bool NonNull(object? instanceMaybe) => instanceMaybe is not null;
        static public bool IPostIsAnswer(IPost ipost) => ipost is Answer;
        static public bool IPostIsComment(IPost ipost) => ipost is Comment;
        static public bool DataRowRepresentsAnswer(DataRow row) => row["type"].ToString() is not null && (row["type"].ToString() == "answer");
        static public bool DataRowRepresentsComment(DataRow row) => row["type"].ToString() is not null && (row["type"].ToString() == "comment");
        static public bool DataRowRepresentsQuestion(DataRow row) => row["type"].ToString() is not null && (row["type"].ToString() == "question");
    }
}