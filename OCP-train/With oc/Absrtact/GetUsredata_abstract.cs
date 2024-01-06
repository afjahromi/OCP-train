using Newtonsoft.Json;
using OCP_train.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP_train.With_oc.absrtact
{
    public abstract class GetUsredata_abstract

    {
        public abstract List<User> GetUsers(string AddressFile);

    }

    public class FromtextFile: GetUsredata_abstract
    {
        public override List<User> GetUsers(string AddressFile)
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
    

    public class Fromejson: GetUsredata_abstract
    {
        public override List<User> GetUsers(string AddressFile)
        {
            string json = File.ReadAllText(AddressFile);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            return users;
        }
    }
}
