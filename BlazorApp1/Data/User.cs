namespace BlazorApp1.Data
{
    public class User
    {
        public User(string name, string email, int age)
        {
            Name = name;
            Email = email;
            Age = age;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User("Vadim", "qqq@mail.ru", 33));
            users.Add(new User("Sergey", "www@mail.ru", 21));
            users.Add(new User("Svyatoslav", "eee@mail.ru", 31));
            users.Add(new User("Liliya", "xxx@mail.ru", 34));
            users.Add(new User("Juliya", "fff@mail.ru", 23));
            return users;
        }
        public static List<User> GetSingleUser()
        {
            List<User> users = new List<User>();
            users.Add(new User("Vadim", "qqq@mail.ru", 33));
            return users;
        }
    }
}
