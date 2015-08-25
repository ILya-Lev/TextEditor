The requirement was to create simple text editor which stores data content in a db
To increase performance content is compressed before sent to db; also db interaction is performed asynchronously
EntityFramework and code first approach is used to create db and to work with it
System.IO.Compression.GZipStream is used to compress/decompress data but it's probable to be changed on some zlib usage

Summary
simple WPF app demonstrates interaction with db, created in 3 days (each day about 6h)
