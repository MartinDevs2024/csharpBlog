namespace csharpBlog.Interfaces
{
    public interface IUnitOfWork
    {
        IPostRepository Post { get; }
        ICategoryRepository Category { get; } // Property to access Category repository
        void Save(); // Method to commit changes to the database
    }
}
