using Newtonsoft.Json;
using OCP_train.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OCP_train.WitoutOpenClosed
{
    public class GetUserData
    {
        public List<User> GetUsers (string AddressFile,FileType fileType )
        {

            if (fileType== FileType.txt)
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
            else
            {
                string json=File.ReadAllText(AddressFile);
                List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
                return users;
            }
           
        }

    }


    public enum FileType
    {
        txt=0,
        json=1,
    }
}
