namespace weather_forecast_backend
{
    public class Location
    {
        public Location(int id, string name, string state, string country)
        {
            Id = id;
            Name = name;
            State = state;
            Country = country;
            //Coordinates = coordinates;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        //public Coordinates Coordinates { get; set; }

    }
}

    /*public class Coordinates
    {
        public Coordinates(double longtitude, double latitude)
        {
            Longtitude = longtitude;
            Latitude = latitude;
        }

        public double Longtitude { get; set; }    
        public double Latitude { get; set; }   

    }
}
    */
