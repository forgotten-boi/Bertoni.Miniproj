using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Bertoni.MiniProj.Models
{
    public class ApiHelper
    {
        public HttpClient httpClient;
      
        public ApiHelper()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://jsonplaceholder.typicode.com");

        }

        public async Task<List<Album>> GetAlbums()
        {
            var albums = new List<Album>();
         
            HttpResponseMessage response = await httpClient.GetAsync("/albums");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                albums = JsonConvert.DeserializeObject<List<Album>>(result);

                return albums;
            }
            return albums;
        }
        public async Task<List<Photo>> GetPhotosByAlbum(int albumId)
        {
            var photos = new List<Photo>();
         
            HttpResponseMessage response = await httpClient.GetAsync($"/albums/{albumId}/photos");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                photos = JsonConvert.DeserializeObject<List<Photo>>(result);

                return photos;
            }
            return photos;
        }
        public async Task<List<Comment>> GetCommentsByPhoto(int photoId)
        {
            var comments = new List<Comment>();
            
            HttpResponseMessage response = await httpClient.GetAsync($"/photos/{photoId}/comments");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                comments = JsonConvert.DeserializeObject<List<Comment>>(result);

                return comments;
            }
            return comments;
        }

    }
}
