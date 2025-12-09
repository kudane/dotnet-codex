# :point_down: Check Code Timer

เครื่องเอาไว้ช่วยจับเวลาการทำงานของโค้ด

```c#
    public class LogResult
    {
        public string? Comment { get; set; }
        public string? Result { get; set; }
    }

    public class LogTimer
    {
        private static readonly Stopwatch stopwatch = new Stopwatch();

        private static readonly List<LogResult> results = new List<LogResult>();
        private static LogResult current = new LogResult();
        private static string filePath = @"c:\LogTimer.txt";

        public static void Init(string path)
        {
            filePath = path;
        }

        public static void Start(string comment)
        {
            current.Comment = comment;
            stopwatch.Start();
        }

        public static void Stop()
        {
            stopwatch.Stop();
            current.Result = stopwatch.Elapsed.TotalMilliseconds.ToString();
            results.Add(current);
            current = new LogResult();
            stopwatch.Restart();
        }

        public static void Close()
        {
            SaveToFile();

            stopwatch.Reset();
            current = new LogResult();
            results.Clear();
        }

        private static void SaveToFile()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (var fs = File.Create(filePath))
            {
                using (var sw = new StreamWriter(fs))
                {
                    foreach (var item in results)
                    {
                        sw.WriteLine($"{item.Comment} : {item.Result} \n");
                    }

                    sw.Close();
                    fs.Close();
                }
            }
        }
    }
```

### วิธีใช้

```c#
// กำหนด path
LogTimer.Init(@"LogTimer.txt");

// จับเวลาโค้ดที่ต้องการ, ประมาณว่าเป็น step 1
LogTimer.Start("step 1");
    Console.WriteLine("Hello, World!");
LogTimer.Stop();

// จับเวลาโค้ดที่ต้องการ, ประมาณว่าเป็น step 2
LogTimer.Start("step 2");
    Console.WriteLine("Hello, World!");
LogTimer.Stop();

// จบการทำงาน และ บันทึกลงไฟล์
LogTimer.Close();
```
