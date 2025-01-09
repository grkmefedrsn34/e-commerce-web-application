namespace ETicaretWebApplication.Ultis
{
    public class File_Helper
    {
        public static async Task<string> FileLoaderASYNC(IFormFile formFile,string filepath ="/image_client/" )
        {
            string file_name = "";
            if( formFile != null && formFile.Length>0 )
            {
                file_name = formFile.Name.ToLower();
                string directroy = Directory.GetCurrentDirectory() + "/wwwroot" + filepath + file_name;
                using var stream = new FileStream(directroy, FileMode.Create);
                await formFile.CopyToAsync(stream);
            }
            return file_name;
        }

        public static bool FileRemove(string filepath = "/wwwroot/image_client/", string file_name = "")
        {
            string directroy = Directory.GetCurrentDirectory() + filepath + file_name;
            if(File.Exists(directroy))
            {
                File.Delete(directroy);
                return true;
            }
            return false;
        }
    }
}
