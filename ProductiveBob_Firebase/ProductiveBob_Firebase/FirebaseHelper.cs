using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace ProductiveBob_Firebase
{
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://productivebob-73eee-default-rtdb.firebaseio.com/");
        public async Task<List<Session>> GetAllSessions()
        {
            return (await firebase
              .Child("Sessions")
              .OnceAsync<Session>()).Select(item => new Session
              {
                  DeviceID = item.Object.DeviceID,
                  ID = item.Object.ID,
                  Rating = item.Object.Rating,
                  Duration = item.Object.Duration,
                  Timestamp = item.Object.Timestamp
              }).ToList();
        }
        public async Task AddSession(string deviceID, Guid id, int rating, TimeSpan duration, string timestamp)
        {
            await firebase
              .Child("Sessions")
              .PostAsync(new Session() { DeviceID = deviceID, ID = id, Rating = rating, Duration = duration, Timestamp = timestamp });
        }

        public async Task<Session> GetSession(Guid ID)
        {
            var allSessions = await GetAllSessions();
            await firebase
              .Child("Sessions")
              .OnceAsync<Session>();
            return allSessions.Where(a => a.ID == ID).FirstOrDefault();
        }
    }
}
