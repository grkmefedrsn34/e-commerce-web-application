namespace ETicaretWebApplication.Ultis
{
    public class File_Helper
    {
        public static async Task<string> FileLoaderASYNC(IFormFile formFile, string filepath = "/image_client/")
        {
            string file_name = "";
            if (formFile != null && formFile.Length > 0)
            {
                try
                {
                    // Dosya adını al ve küçük harfe çevir
                    file_name = Path.GetFileName(formFile.FileName).ToLower();

                    // Tam dosya yolunu oluştur
                    string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filepath.TrimStart('/'));
                    string fullPath = Path.Combine(directoryPath, file_name);

                    // Klasör yoksa oluştur
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    // Dosyayı oluştur ve kopyala
                    using var stream = new FileStream(fullPath, FileMode.Create);
                    await formFile.CopyToAsync(stream);
                }
                catch (Exception ex)
                {
                    // Hata yönetimi
                    Console.WriteLine($"Dosya yükleme sırasında bir hata oluştu: {ex.Message}");
                    throw;
                }
            }

            return file_name;
        }

        public static bool FileRemove(string filepath = "/wwwroot/image_client/", string file_name = "")
        {
            try
            {
                // Tam dosya yolunu oluştur
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filepath.TrimStart('/'), file_name);

                // Dosya mevcutsa sil
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                Console.WriteLine($"Dosya silme sırasında bir hata oluştu: {ex.Message}");
            }

            return false;
        }
    }
}
