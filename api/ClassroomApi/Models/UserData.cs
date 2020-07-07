namespace ClassroomApi.Models
{
    public class UserData
    {
        public string Username { get; set; }
        public string ClassName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is UserData data &&
                   Username == data.Username &&
                   ClassName == data.ClassName;
        }
    }
}
