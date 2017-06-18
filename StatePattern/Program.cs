using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context=new Context();
            context.liftState = Context.closingState;

            context.Open();
            context.Close();
            context.Run();
            context.Stop();
            Console.ReadKey();
        }
    }

    public abstract class LiftState
    {
        public Context context { get; set; }

        public abstract void Open();
        public abstract void Close();
        public abstract void Run();
        public abstract void Stop();

    }

    public class Context
    {
        public static OpenningState openningState=new OpenningState();
        public static ClosingState closingState = new ClosingState();
        public static RunningState runningState = new RunningState();
        public static StoppingState stoppingState = new StoppingState();

        private LiftState _liftState;
        public LiftState liftState
        {
            get { return _liftState; }
            set
            {
                _liftState = value;
                liftState.context=this;
            }
        }

        public void Open()
        {
            liftState.Open();
        }

        public void Close()
        {
            liftState.Close();
        }

        public void Run()
        {
            liftState.Run();
        }

        public void Stop()
        {
            liftState.Stop();
        }
    }

    public class OpenningState:LiftState
    {

        public override void Open()
        {
            Console.WriteLine("电梯门开启...");
        }

        public override void Close()
        {
            context.liftState = Context.closingState;
            context.liftState.Close();
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }
    }

    public class ClosingState : LiftState
    {

        public override void Open()
        {
            Console.WriteLine("门开了...");
        }

        public override void Close()
        {
            Console.WriteLine("门要关了...");
        }

        public override void Run()
        {
            context.liftState = Context.runningState;
            context.liftState.Run();
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }
    }

    public class RunningState : LiftState
    {

        public override void Open()
        {
            throw new NotImplementedException();
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void Run()
        {
            Console.WriteLine("电梯开了...");
        }

        public override void Stop()
        {
            context.liftState = Context.stoppingState;
            context.liftState.Stop();
        }
    }

    public class StoppingState : LiftState
    {

        public override void Open()
        {
            context.liftState = Context.openningState;
            context.liftState.Open();
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }

        public override void Stop()
        {
            Console.WriteLine("电梯停下来了...");
        }
    }
}
