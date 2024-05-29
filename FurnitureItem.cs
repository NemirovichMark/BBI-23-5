namespace ConsoleApplication1
{
    
    using System.Drawing;
    using Newtonsoft.Json;
    using JsonSubTypes;

    //[JsonDerivedType(typeof(Chair), typeDiscriminator: "Chair")]
    //[JsonDerivedType(typeof(Table), typeDiscriminator: "Table")]
    //[JsonDerivedType(typeof(Sofa), typeDiscriminator: "Sofa")]
    //[JsonDerivedType(typeof(Bed), typeDiscriminator: "Bed")]
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(Chair), "Chair")]
    [JsonSubtypes.KnownSubType(typeof(Table), "Table")]
    [JsonSubtypes.KnownSubType(typeof(Sofa), "Sofa")]
    [JsonSubtypes.KnownSubType(typeof(Bed), "Bed")]
    public abstract class FurnitureItem
    {
        protected string Model;
        protected string Brand;
        protected double Price;

        public double price { get { return Price; } }
        public string model { get { return Model; } }
        public string brand { get { return Brand; } }
        public abstract string Type { get; }

        public FurnitureItem(string model, string brand)
        {
            Model = model;
            Brand = brand;
            Price = CalculatePrice();
        }

        protected abstract double CalculatePrice();

        public void SetPrice()
        {
            Price = CalculatePrice();
        }

        public override string ToString()
        {
            return $"{Model} бренда {Brand} по цене {Price}";
        }
        public virtual string ToXML()
        {
            string res = "";
            res += $"<Model>{Model}</Model>\n";
            res += $"<Brand>{Brand}</Brand>\n";
            res += $"<Price>{Price}</Price>\n";
            return res;
        }
    }
    public class Bed : FurnitureItem
    {
        protected bool CustomSize;
        protected bool BunkBed;

        public bool customSize
        {
            get => CustomSize;
            set => CustomSize = value;
        }
        public bool bunkBed
        {
            get => BunkBed;
            set => BunkBed = value;
        }

        public Bed(string model, string brand, bool customSize, bool bunkBed)
            : base(model, brand)
        {
            CustomSize = customSize;
            BunkBed = bunkBed;
            SetPrice();
        }

        protected override double CalculatePrice()
        {
            double price = 10000;
            if (CustomSize) price += 6000;
            if (BunkBed) price *= 2;
            return price;
        }

        public override string Type => "Bed";
        public override string ToXML()
        {
            string res = base.ToXML();
            res += $"<CustomSize>{CustomSize}</CustomSize>\n";
            res += $"<BunkBed>{BunkBed}</BunkBed>\n";
            return res;
        }
    }
    public class Sofa : FurnitureItem
    {
        protected bool Angular;
        protected bool Folding;

        public bool angular
        {
            get => Angular;
            set => Angular = value;
        }
        public bool folding
        {
            get => Folding;
            set => Folding = value;
        }

        public Sofa(string model, string brand, bool angular, bool folding)
            : base(model, brand)
        {
            Angular = angular;
            Folding = folding;
            SetPrice();
        }

        protected override double CalculatePrice()
        {
            double price = 20000;
            if (Angular) price += 5000;
            if (Folding) price += 4000;
            return price;
        }

        public override string Type => "Sofa";
        public override string ToXML()
        {
            string res = base.ToXML();
            res += $"<Angular>{Angular}</Angular>\n";
            res += $"<Folding>{Folding}</Folding>\n";
            return res;
        }
    }
    public class Chair : FurnitureItem
    {
        protected bool HasBack;
        protected bool HasWheels;

        public bool hasBack
        {
            get => HasBack;
            set => HasBack = value;
        }
        public bool hasWheels
        {
            get => HasWheels;
            set => HasWheels = value;
        }

        public Chair(string model, string brand, bool hasBack, bool hasWheels)
            : base(model, brand)
        {
            HasBack = hasBack;
            HasWheels = hasWheels;
            SetPrice();
        }

        protected override double CalculatePrice()
        {
            double price = 2000;
            if (HasBack) price += 500;
            if (HasWheels) price += 700;
            return price;
        }

        public override string Type => "Chair";
        public override string ToXML()
        {
            string res = base.ToXML();
            res += $"<HasBack>{HasBack}</HasBack>\n";
            res += $"<HasWheels>{HasWheels}</HasWheels>\n";
            return res;
        }
    }
    class Armchair : Chair
    {
        protected string Coating;

        public string GetCoating()
        {
            return Coating;
        }

        public Armchair(string Model, string Brand, double Price, bool HasBack, bool HasWheels, string coating = "Кожа") : base(Model, Brand, HasBack, HasWheels)
        {
            Coating = coating;
        }

        protected override double CalculatePrice()
        {
            Price = 2000;
            if (HasBack)
            {
                Price += 500;
            }
            if (HasWheels)
            {
                Price += 700;
            }
            Price += 10000;
            return Price;
        }

        public override string ToXML()
        {
            string res = base.ToXML();
            res += $"<Coating>{Coating}</Coating>\n";
            return res;
        }
    }
    class Stool : Chair
    {
        public Stool(string Model, string Brand, double Price) : base(Model, Brand, false, false)
        {
        }
    }
    public class Table : FurnitureItem
    {
        protected int NumberOfPlaces = 1;
        protected bool Foldable;

        public int numberOfPlaces
        {
            get => NumberOfPlaces;
            set => NumberOfPlaces = value;
        }
        public bool foldable
        {
            get => Foldable;
            set => Foldable = value;
        }

        public Table(string model, string brand, int numberOfPlaces, bool foldable)
            : base(model, brand)
        {
            Foldable = foldable;
            if (numberOfPlaces > 1)
            {
                NumberOfPlaces = numberOfPlaces;
            }
            SetPrice();
        }

        protected override double CalculatePrice()
        {
            double price = 5052;
            if (Foldable) price += 1500;
            if (NumberOfPlaces > 4) price += 2000;
            if (NumberOfPlaces > 10) price += 4000;
            return price;
        }

        public override string Type => "Table";
        public override string ToXML()
        {
            string res = base.ToXML();
            res += $"<NumberOfPlaces>{NumberOfPlaces}</NumberOfPlaces>\n";
            res += $"<Foldable>{Foldable}</Foldable>\n";
            return res;
        }
    }
}