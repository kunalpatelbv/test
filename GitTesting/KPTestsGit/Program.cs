using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KPTestsGit
{
    class Program
    {
        static void Main( string[] args )
        {

            List<Task<int>> tasks = Enumerable.Range( 0, 1000).Select( i => new Task<int>( () => i * i ) ).ToList();
            tasks.ForEach( t => t.Start() );
            Task.WaitAll( tasks.ToArray() );
            tasks.ForEach( t =>
            {
                Console.WriteLine( t.Result );
                Thread.Sleep( 5 );
            } );
            Console.ReadLine();
        }
    }
}