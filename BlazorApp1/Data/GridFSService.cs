using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class GridFSService
    {
        FileInfo file;
        const string conectionString = "mongodb://localhost";
        public void UploadImageToDB()
        {
            MongoClient client = new MongoClient(conectionString);
            IMongoDatabase database = client.GetDatabase("Images");
            IGridFSBucket gridFs = new GridFSBucket(database);          
            using(FileStream fs = new FileStream("E:/repos/ITParkBlazorApp/BlazorApp4/wwwroot/boot.jpg", FileMode.Open))
            {
                gridFs.UploadFromStream("qqq.jpg", fs);
            }
        }

        public async Task UploadImageToDBAsync(Stream stream)
        {
            MongoClient client = new MongoClient(conectionString);
            IMongoDatabase database = client.GetDatabase("FilesITPark");
            IGridFSBucket gridFs = new GridFSBucket(database);
            await gridFs.UploadFromStreamAsync("sss", stream);
        }

        public async Task ReplaceImage()
        {
            MongoClient client = new MongoClient(conectionString);
            IMongoDatabase database = client.GetDatabase("Images");
            IGridFSBucket gridFs = new GridFSBucket(database);
            var filter = Builders<GridFSFileInfo>.Filter.Eq(x => x.Filename, "qqq.jpg");
            var gridFileInfo = gridFs.Find(filter).FirstOrDefault();
            var id = gridFileInfo.Id;
            await gridFs.DeleteAsync(id);
            using (FileStream fs = new FileStream("E:/repos/ITParkBlazorApp/BlazorApp4/wwwroot/boot.jpg", FileMode.Open))
            {
                await gridFs.UploadFromStreamAsync("qqq.jpg", fs);
            }
        }

        public void DownloadImageToWWWRoot(string filename)
        {
            MongoClient client = new MongoClient(conectionString);
            IMongoDatabase database = client.GetDatabase("FilesITPark");
            IGridFSBucket gridFs = new GridFSBucket(database);

            using (Stream fs = new FileStream($"{Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/RandomFiles/")}{filename}.jpg", FileMode.CreateNew))
            {
                gridFs.DownloadToStreamByName("sss", fs);
                //file = new FileInfo("boot.jpg");
                //Console.WriteLine(file.DirectoryName);
                //*пример с получением id файла и выгрузка из БД по id*
                //var filter = Builders<GridFSFileInfo>.Filter.Eq(x => x.Filename, "qqq.jpg");
                //var gridFileInfo = gridFs.Find(filter).FirstOrDefault();
                //gridFs.DownloadToStream(gridFileInfo.Id, fs);

                //*получение всех имен файлов из GridFS привязанных к базе Images*
                //var ff= gridFs.Find(Builders<GridFSFileInfo>.Filter.Empty).ToList();
                // foreach(var item in ff)
                // {
                //     Console.WriteLine(item.Filename);
                // }
            }


        }
    }
}
