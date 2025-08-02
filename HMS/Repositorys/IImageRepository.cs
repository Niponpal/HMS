namespace HMS.Repositorys
{
    public interface IImageRepository
    {
        Task<string> UploadAsync(IFormFile file);
    }
}
