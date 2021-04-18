using System;

namespace ConsoleApp1
{

    /*-----------------Lecture 24-------------------------*/


    delegate void MyEventHandler();
    //publisher
    internal class MyButton
    {
        public event MyEventHandler click;

        public void OnClick()
        {
            //click.Invoke();
            click();
        }
    }

    internal class MySubscriber
    {
        static public void HandleEvent()
        {

            Console.WriteLine("Click event occured.");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            MyButton button = new MyButton();
            button.click += MySubscriber.HandleEvent;

            button.click += delegate ()
            {
                Console.WriteLine("click event second handler");
            };

            button.OnClick();
        }
    }



    /*-----------------Lecture 25-------------------------*/

    //delegate void PublishMessageDel(string msg);

    //class Publisher
    //{

    //    //public PublishMessageDel publishMessageObj = null;
    //    public event PublishMessageDel publishevent = null;

    //    public void PublishMessage(string msg)
    //    {

    //        publishevent.Invoke(msg);
    //    }
    //}
    ////subscribers
    //class SendViaEmailSubscriber
    //{

    //    public void Subscribe(Publisher p)
    //    {

    //        p.publishevent += SendMessage;
    //    }
    //    private void SendMessage(string msg)
    //    {

    //        Console.WriteLine($"Send to Email {msg}");
    //    }


    //}

    //class SendViaMobileSubscriber
    //{

    //    public void Subscribe(Publisher p)
    //    {
    //        p.publishevent += SendMessage;


    //    }
    //    private void SendMessage(string msg)
    //    {
    //        Console.WriteLine($"Send to Mobile {msg}");
    //    }

    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Publisher publisherObj = new Publisher();
    //        SendViaEmailSubscriber emailObj = new SendViaEmailSubscriber();
    //        SendViaMobileSubscriber mobObj = new SendViaMobileSubscriber();

    //        emailObj.Subscribe(publisherObj);
    //        mobObj.Subscribe(publisherObj);
    //        //publisherObj.publishMessageObj = emailObj.SendMessage;
    //        //publisherObj.publishMessageObj += mobObj.SendMessage;

    //        publisherObj.PublishMessage("Hello, You have a new notification");

    //    }
    //}


    /*----------------Lecture 26------------------*/


    //class MyEventArgs : EventArgs
    //{
    //    public int Count { get; set; }

    //}

    //delegate void MyEventHandler(object sender, MyEventArgs e);
    ////delegate void MyEventHandler();
    ////publisher
    //class MyArrayList : ArrayList
    //{
    //    public event MyEventHandler Added;
    //    MyEventArgs e = new MyEventArgs();
    //    public MyArrayList()
    //    {

    //        e.Count = 0;
    //    }
    //    void OnAdded()
    //    {
    //        if (Added != null)
    //        {
    //            e.Count = e.Count + 1;
    //            Added(this, e);
    //        }
    //    }
    //    public override int Add(object value)
    //    {
    //        OnAdded();
    //        return base.Add(value);
    //    }
    //}
    
    ////subscriber
    
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        MyArrayList list = new MyArrayList();
    //        list.Added += (object sender, MyEventArgs e) => Console.WriteLine($"object added by {sender.ToString()} and count :{e.Count}");
    //        list.Add(1);
    //        list.Add("1");
    //        list.Add("1234");

    //    }
    //}

}
