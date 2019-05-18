using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace _0516
{
    class MainApp
    {
        static void Main(string[] args)
        {
            /// 스레드
            Thread th = new Thread(new ThreadStart(BlueFlag));      // ThreadStart => delegate(대리자) => 메소드 BlueFlag를 받고 있음
            WriteLine("Start Thread");
            th.Start();
            for (int i = 0; i < 10; i++)
            {
                WriteLine("백기");
                Thread.Sleep(15);
            }
            WriteLine("---백기끝---");

            WriteLine("Waiting until thread stop...");
            th.Join();      // 청기스레드가 끝날때까지 기다린다(메인스레드가!)

            WriteLine("Finished");

            /// 스레드 중지
            // 스레드 중지시키기 abort();
            // abort(); => CLR측이 강제적으로 스레드를 중지하게됨 => 지양
            // ThreadAbortException() 사용 => 외부에서 abort() 신호받으면 무조건 스레드 죽임
            Thread thInf = new Thread(new ThreadStart(BlueFlagInf));
            WriteLine("Start Thread");
            thInf.Start();

            Thread.Sleep(100);

            WriteLine("Aborting thread...");
            thInf.Abort();      // 청기스레드를 중단시킴


            thInf.Join();

            WriteLine("Finished");

            // Abort()를 사용하지 않고 스레드 중지하는 방법
            // => flag 사용하기
            Thread thInf2 = new Thread(new ThreadStart(BlueFlagInf2));
            WriteLine("Start Thread");
            thInf2.Start();

            Thread.Sleep(100);

            WriteLine("Aborting thread...");
            setStop = true;

            WriteLine("Finished");

            // ThreadInterruptException() 으로 중단처리하기
            // 외부에서 interrupt() 신호받으면 Wait/sleep/join() 으로 자고 잇는 스레드를 깨움
            // 단, wait/sleep/join으로 자고 있지 않으면 영향없음 => 스레드내부에 wait/sleep/join을 꼭 위치해야함
            // flag를 못쓰는 상황이면 interrupt 사용하기
            /// abort()와 interrupt()신호 차이(시험문제)
            Thread thInf3 = new Thread(new ThreadStart(BlueFlagInf3));
            WriteLine("Start Thread");
            thInf3.Start();

            Thread.Sleep(100);

            WriteLine("Interrupting thread...");
            thInf3.Interrupt();

            WriteLine("Finished");

            // 스레드 동기화 => Critical Section
            // CS주는 방법 1.참조타입의 키값으로 lock () 걸어주기
            Counter counter = new Counter();

            Thread thInc = new Thread(new ThreadStart(counter.Increase));
            Thread thDec = new Thread(new ThreadStart(counter.Decrease));

            thInc.Start();
            thDec.Start();

            thInc.Join();
            thDec.Join();

            WriteLine(counter.Count);

            // CS주는 방법 2. try/catch + Monitor(Enter/Exit)
            Counter counterMon = new Counter();

            Thread thIncM = new Thread(new ThreadStart(counterMon.IncreaseMon));
            Thread thDecM = new Thread(new ThreadStart(counterMon.DecreaseMon));

            thIncM.Start();
            thDecM.Start();

            thIncM.Join();
            thDecM.Join();

            WriteLine(counterMon.Count);

            // CS주는 방법 3. try/catch +Monitor(Wait / Pulse)
            Counter counterMon2 = new Counter();

            Thread thIncM2 = new Thread(new ThreadStart(counterMon2.IncreaseMon2));
            Thread thDecM2 = new Thread(new ThreadStart(counterMon2.DecreaseMon2));

            thIncM2.Start();
            thDecM2.Start();

            thIncM2.Join();
            thDecM2.Join();

            WriteLine(counterMon2.Count);

            // 비동기 코드 => Task 클래스
            // using System.Threading.Task;
            string srcFile = args[0];
            Action<object> FileCopyAction = (object state) =>
            {
                string[] paths = (string[])state;
                File.Copy(paths[0], paths[1]);
                WriteLine($"TaskID: {Task.CurrentId}, ThreadID: {Thread.CurrentThread.ManagedThreadId}, {paths[0]} was copied to {paths[1]}");
            };

            // 방법 1
            Task t1 = new Task(FileCopyAction, new string[] { srcFile, srcFile + " .copy1" });
            t1.Start();

            // 방법 2
            Task t2 = Task.Run(() =>
            {
                FileCopyAction(new string[] { srcFile, srcFile + " .copy2" });
            });

            // 방법 3
            Task t3 = new Task(FileCopyAction, new string[] { srcFile, srcFile + " .copy3" });
            t3.RunSynchronously();

            t1.Wait();
            t2.Wait();
            // 서내 알러뷰 ㅎ...ㅎ..

            // 큰 범위를 여러개로 쪼개고 각 범위를 각 스레드가 실행하게 함
            // 이 기능을 제공하는 클래스도 있음(아래아래)
            long from = Convert.ToInt64(args[0]);
            long to = Convert.ToInt64(args[1]);       // int.Parse() 써도 됨
            int taskCount = Convert.ToInt32(args[2]);

            Func<object, List<long>> FindPrimeFunc = (objRange) =>
            {
                long[] range = (long[])objRange;
                List<long> found = new List<long>();
                for (long i = range[0]; i <= range[1]; i++)
                    if (IsPrime(i))
                        found.Add(i);
                return found;
            };

            Task<List<long>>[] tasks = new Task<List<long>>[taskCount];     // taskCount수만큼 Task배열 만듦
            long curFrom = from;
            long curTo = from + (to - from) / tasks.Length;

            for (int i = 0; i < tasks.Length; i++)
            {
                WriteLine($"Task[{i}] :: {curFrom} ~ {curTo}");
                tasks[i] = new Task<List<long>>(FindPrimeFunc, new long[] { curFrom, curTo });
                curFrom = curTo + 1;
                //if (i == tasks.Length - 2) curTo = to;
                //else curTo += ((to - from) / tasks.Length);
                curTo = ((i == tasks.Length - 2) ? to : (curTo + (to - from) / tasks.Length));
            }

            WriteLine("Please press enter to start...");
            ReadLine();
            WriteLine("Started...");

            DateTime startTime = DateTime.Now;
            foreach (Task<List<long>> task in tasks)
                task.Start();

            List<long> total = new List<long>();
            foreach (Task<List<long>> task in tasks)
                total.AddRange(task.Result.ToArray());

            DateTime endTime = DateTime.Now;
            TimeSpan ellapsed = endTime - startTime;
            WriteLine($"Prime number count between {from} and {to} : {total.Count}");
            WriteLine($"Ellapsed time : {ellapsed}");



            // 범위를 나누고 각 범위마다 각 스레드가 수행하는 작업을 위한 클래스 Pallel 
            long fromC = Convert.ToInt64(args[0]);
            long toC = Convert.ToInt64(args[1]);       // int.Parse() 써도 됨

            WriteLine("Please press enter to start...");
            ReadLine();
            WriteLine("Started...");

            DateTime startTimeC = DateTime.Now;
            List<long> totalC = new List<long>();

            Parallel.For(fromC, toC + 1, (long i) =>
            {
                if (IsPrime(i)) totalC.Add(i);
            });

            DateTime endTimeC = DateTime.Now;
            TimeSpan ellapsedC = endTimeC - startTimeC;
            WriteLine($"Prime number count between {fromC} and {toC} : {totalC.Count}");
            WriteLine($"Ellapsed time : {ellapsedC}");


            // async
            Caller();
            WriteLine("#################");
            ReadLine();         // 스레드 동작 확인 후 끄려고 메인스레드 대기시킴
        }

        static void BlueFlag()
        {
            for (int i = 0; i < 10; i++)
            {
                WriteLine("청기");
                Thread.Sleep(10);
            }
            WriteLine("---청기끝---");
        }

        static void BlueFlagInf()
        {
            try
            {
                while (true)            // C#에서  while문은 boolean타입만 받는다
                {
                    WriteLine("청기");
                    Thread.Sleep(10);
                }
            } 
            catch (ThreadAbortException e)
            {
                WriteLine(e);
                Thread.ResetAbort();
            } 
            finally
            {
                WriteLine("리소스 해제");
            }
        }

        static Boolean setStop = false;
        static void BlueFlagInf2()
        {
            while (!setStop)
            {
                WriteLine("청기");
                Thread.Sleep(10);
            }
            WriteLine("추가작업");
        }

        static void BlueFlagInf3()
        {
            try
            {
                while (true)            
                {
                    WriteLine("청기");
                    Thread.Sleep(10);
                }
            }
            catch (ThreadInterruptedException e)
            {
                WriteLine(e);
            }
            finally
            {
                WriteLine("리소스 해제");
            }
            WriteLine("추가작업");
        }

        class Counter
        {
            const int LOOP_COUNT = 1000;
            readonly object thisLock;           // CS를 들어가기 위한 일종의 티켓
            private int count;
            private bool lockedCount = false;
            public int Count { get { return count; } }
            public Counter()
            {
                thisLock = new object();
                count = 0;
            }

            public void Increase()
            {
                int loopCount = LOOP_COUNT;
                while(loopCount-- > 0)
                {
                    lock(thisLock)      // lock() {...} 부분이 CS구역
                    {
                        count++;
                    }
                    Thread.Sleep(1);
                }
            }
            
             public void Decrease()
            {
                int loopCount = LOOP_COUNT;
                while(loopCount-- > 0)
                {
                    lock(thisLock)      // InCrease()와 Decrease()의 lock영역이 모두 같은 키값으로 Cs를 지키고 있음
                    {                   // 증가할동안은 감소하는 작업이 일어나면 안되므로 당연한 얘기
                        count--;
                    }
                    Thread.Sleep(1);
                }
            }

            public void IncreaseMon()
            {
                int loopCount = LOOP_COUNT;
                while (loopCount-- > 0)
                {
                    Monitor.Enter(thisLock);
                    try      
                    {
                        count++;
                    }
                    finally
                    {
                        Monitor.Exit(thisLock);
                    }
                    Thread.Sleep(1);
                }
            }

            public void DecreaseMon()
            {
                int loopCount = LOOP_COUNT;
                while (loopCount-- > 0)
                {
                    Monitor.Enter(thisLock);
                    try      // lock() {...} 부분이 CS구역
                    {
                        count--;
                    }
                    finally
                    {
                        Monitor.Exit(thisLock);     // 예외 발생여부와 상관없이 호출되게 하기 위해 finally에 작성
                    }
                    Thread.Sleep(1);
                }
            }

            public void IncreaseMon2()
            {
                int loopCount = LOOP_COUNT;
                while (loopCount-- > 0)
                {
                    lock (thisLock)      // lock() {...} 부분이 CS구역
                    {
                        if (count > 0 || lockedCount == true)
                            Monitor.Wait(thisLock);
                        lockedCount = true;
                        count++;
                        lockedCount = false;
                        Monitor.Pulse(thisLock);
                    }
                }
            }

            public void DecreaseMon2()
            {
                int loopCount = LOOP_COUNT;
                while (loopCount-- > 0)
                {
                    lock (thisLock)      // lock() {...} 부분이 CS구역
                    {
                        if (count > 0 || lockedCount == true)
                            Monitor.Wait(thisLock);
                        lockedCount = true;
                        count--;
                        lockedCount = false;
                        Monitor.Pulse(thisLock);
                    }
                }
            }
        }

        static bool IsPrime(long num)
        {
            if (num < 2) return false;
            if (num % 2 == 0 && num != 2) return false;

            for(long i = 2; i < num; i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }

        /* 이 메소드는 async이므로 Task를 만났을 때 새 스레드가 Task안쪽 코드를 실행하게끔 넘겨주고
         * 메인스레드 자신은 빠져나옴 => 이때 async가 붙어있는 대상은 MyMethodAsync자체이므로 Caller()에서 C, D부분 지점으로 빠져나옴 */
        async static private void MyMethodAsync(int count)          
        {                                                       
            WriteLine("C");
            WriteLine("D");

           await Task.Run(() =>                        // await의 의미: 스레드가 Task실행문을 완료하고 나면, 그냥 죽지 말고 뒷문장(G,H)부분을 수행하고 죽는다.
           {                                           // Task로 만든 비동기는 언제 실행될지 보장받을 수 없으나
               for (int i = 1; i <= count; i++)        // await은 메인 스레드가 이후진행을 하기전에 반드시 실행해야 하는 구문을 먼저 모두 완료할 수 있도록 보장한다.
               {
                   WriteLine($"{i}/{count}...");  
                   Thread.Sleep(100);
               }
           });

            WriteLine("G");
            WriteLine("H");
        }

        static void Caller()
        {
            WriteLine("A");
            WriteLine("B");

            MyMethodAsync(3);

            WriteLine("E");
            WriteLine("F");
        }

    } // class Program
} // namespace _0516
