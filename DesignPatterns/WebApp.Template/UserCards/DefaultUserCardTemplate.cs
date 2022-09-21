﻿namespace WebApp.Template.UserCards
{
    public class DefaultUserCardTemplate : UserCardTemplate
    {
        protected override string SetFooter()
        {
            return string.Empty;
        }

        protected override string SetPicture()
        {
            return "<img src='/UserPictures/user1.png' class='card-img-top'>";
        }
    }
}
