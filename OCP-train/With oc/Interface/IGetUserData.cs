using OCP_train.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP_train.With_oc.Interface
{
    public interface IGetUserData
    {
        List<User> GetUsers(string AddressFile);
    }

    public class Frometxtdata : IGetUserData
    {
        public List<User> GetUsers(string AddressFile)
        {
            var Stresm = File.OpenText(AddressFile).BaseStream;

            List<string> lines = new List<string>();
            using (var reader = new StreamReader(Stresm))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }


            }
            List<User> users = new List<User>();
            foreach (var item in lines)
            {
                var fields = item.Split(',');
                int Id = int.Parse(fields[0]);
                string FirstName = fields[1];
                string LastName = fields[2];
                User user = new User()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Id = Id,
                };
                users.Add(user);
            }
            return users;
        }
    }




}
