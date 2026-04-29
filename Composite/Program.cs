// See https://aka.ms/new-console-template for more information
using Composite.FileSystem;

var images = new DirectoryItem("images");
images.Add(new FileItem("photo.jpg", 1048576));
images.Add(new FileItem("logo.png", 32768));

var documents = new DirectoryItem("documents");
documents.Add(new FileItem("report.pdf", 204800));
documents.Add(new FileItem("notes.txt", 2048));
documents.Add(images);

var root = new DirectoryItem("root");
root.Add(new FileItem("boot.cfg", 512));
root.Add(new FileItem("readme.txt", 1024));
root.Add(documents);

root.Display();

Console.WriteLine($"Total size of '{root.GetName()}': {root.GetSize()} bytes");

/*
/root
├── boot.cfg         (512 bytes)
├── readme.txt       (1024 bytes)
└── /documents
    ├── report.pdf   (204800 bytes)
    ├── notes.txt    (2048 bytes)
    └── /images
        ├── photo.jpg  (1048576 bytes)
        └── logo.png   (32768 bytes)
*/