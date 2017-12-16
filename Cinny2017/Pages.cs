namespace Cinny2017
{
    static class Pages
    {
        private static StartPage _startPage = new StartPage();
        private static SignupPage _signupPage = new SignupPage();
        private static ShowswatchedPage _showswatchedPage = new ShowswatchedPage();
        private static ShowsplannedPage _showsplannedPage = new ShowsplannedPage();
        private static ShowssearchPage _showssearchPage = new ShowssearchPage();
        private static MovieswatchedPage _movieswatchedPage = new MovieswatchedPage();
        private static MoviesplannedPage _moviesplannedPage = new MoviesplannedPage();
        private static MoviessearchPage _moviessearchPage = new MoviessearchPage();

        public static ShowsplannedPage ShowsplannedPage
        {
            get
            {
                return _showsplannedPage;
            }
        }

        public static ShowssearchPage ShowssearchPage
        {
            get
            {
                return _showssearchPage;
            }
        }

        public static MovieswatchedPage MovieswatchedPage
        {
            get
            {
                return _movieswatchedPage;
            }
        }

        public static MoviesplannedPage MoviesplannedPage
        {
            get
            {
                return _moviesplannedPage;
            }
        }

        public static MoviessearchPage MoviessearchPage
        {
            get
            {
                return _moviessearchPage;
            }
        }

        public static StartPage StartPage
        {
            get
            {
                return _startPage;
            }
        }

        public static SignupPage SignupPage
        {
            get
            {
                return _signupPage;
            }
        }

        public static ShowswatchedPage ShowswatchedPage
        {
            get
            {
                return _showswatchedPage;
            }
        }
    }
}
