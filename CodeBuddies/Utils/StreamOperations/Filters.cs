using System.Data;

namespace CodeBuddies.Utils.Functionals
{
    internal class Filters
    {
        static public bool NonNull(object? instanceMaybe) => instanceMaybe is not null;
        // static public bool IPostIsIAnswer(IPost ipost) => ipost is IAnswer;
        // static public bool IPostIsIComment(IPost ipost) => ipost is IComment;
        static public bool DataRowRepresentsAnswer(DataRow row) => row["type"].ToString() is not null && (row["type"].ToString() == "answer");
        static public bool DataRowRepresentsComment(DataRow row) => row["type"].ToString() is not null && (row["type"].ToString() == "comment");
        static public bool DataRowRepresentsQuestion(DataRow row) => row["type"].ToString() is not null && (row["type"].ToString() == "question");
    }
}
