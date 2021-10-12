namespace Sheduler
{
    internal class ApiResponse
    {
        public bool ok;
        public file result;
    }
    struct file
    {
        public string file_id;
        public string file_unique_id;
        public int file_size;
        public string file_path;

    }

}