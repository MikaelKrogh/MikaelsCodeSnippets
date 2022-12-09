public class GrabStocks {
    public static void Main(string[] args) {
        StockGrabber stockGrabber = new StockGrabber();
        StockObserver observer1 = new StockObserver(stockGrabber);

        stockGrabber.setIbmPrice(20);
        stockGrabber.setAaplPrice(21);

        Thread.Sleep(500);

        stockGrabber.setIbmPrice(22.54);
        stockGrabber.setAaplPrice(25.54);

    }
}


public interface Subject {
    public void Register(Observer observer);
    public void unregister(Observer observer);
    public void notifyObserver();
}


public interface Observer {
    public void Update(double imbPrice, double aaplPrice);
}

public class StockGrabber : Subject {

    List<Observer> stocklist = new List<Observer>();
    private double IbmPrice;
    private double AaplPrice;
    public void notifyObserver() {
        foreach (Observer item in stocklist)
        {
            item.Update(IbmPrice, AaplPrice);
        }
    }

    public void Register(Observer observer) {
        stocklist.Add(observer);
        Console.WriteLine("Observer added");
    }

    public void unregister(Observer observer) {
        stocklist.Remove(observer);
    }
    public void setIbmPrice(double newprice) {
        this.IbmPrice = newprice;
        notifyObserver();
    }
    public void setAaplPrice(double newprice) {
        this.AaplPrice = newprice;
        notifyObserver();
    }
}

public class StockObserver : Observer {
    private double ibmPrice;
    private double aaplPrice;
    private static int ObserverIdTracker = 0;
    private int ObserverId;
    private Subject stockGrabber;
    public StockObserver(Subject stockgrabber) {
        this.stockGrabber = stockgrabber;
        this.ObserverId = ++ObserverIdTracker;
        stockGrabber.Register(this);
    }

    public void PrintThePrices() {
        Console.WriteLine(ObserverId);
        Console.WriteLine("IBM: " + ibmPrice);
        Console.WriteLine("AAPL: " + aaplPrice);
    }

    public void Update(double imbPrice, double aaplPrice) {
        this.ibmPrice = imbPrice;
        this.aaplPrice = aaplPrice;
        PrintThePrices();
    }
}



