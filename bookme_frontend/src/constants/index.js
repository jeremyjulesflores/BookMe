import {facebook, instagram, linkedin, twitter, star  } from "../assets";

export const textLinkFields=[
  {
    page:"Landing",
    details:{
      paragraph:"Want to learn more about us?",
      linkName:"Learn More",
      linkUrl:"/"
    }
  },
  {
    page:"Signup",
    details:{
      paragraph:"Don't have an account yet?",
      linkName:"Signup",
      linkUrl:"/signup"
    }
  },
  {
    page:"Login",
    details:{
      paragraph:"Already have an account?",
      linkName:"Login",
      linkUrl:"/login"
    }
  }
]

export const loginFields=[
  {
      labelText:"Email address",
      labelFor:"email-address",
      id:"emailaddress",
      name:"email",
      type:"email",
      autoComplete:"email",
      isRequired:true,
      placeholder:"Email address"   
  },
  {
      labelText:"Password",
      labelFor:"password",
      id:"password",
      name:"password",
      type:"password",
      autoComplete:"current-password",
      isRequired:true,
      placeholder:"Password"   
  }
]

export const signupFields=[
  {
      labelText:"First Name",
      labelFor:"first-name",
      id:"first-name",
      name:"first-name",
      type:"text",
      autoComplete:"first-name",
      isRequired:true,
      placeholder:"First Name"   
  },
  {
    labelText:"Last Name",
    labelFor:"last-name",
    id:"last-name",
    name:"last-name",
    type:"text",
    autoComplete:"last-name",
    isRequired:true,
    placeholder:"Last Name"   
},
  {
      labelText:"Email address",
      labelFor:"email-address",
      id:"email-address",
      name:"email",
      type:"email",
      autoComplete:"email",
      isRequired:true,
      placeholder:"Email address"   
  },
  {
      labelText:"Password",
      labelFor:"password",
      id:"password",
      name:"password",
      type:"password",
      autoComplete:"current-password",
      isRequired:true,
      placeholder:"Password"   
  },
  {
      labelText:"Confirm Password",
      labelFor:"confirm-password",
      id:"confirm-password",
      name:"confirm-password",
      type:"password",
      autoComplete:"confirm-password",
      isRequired:true,
      placeholder:"Confirm Password"   
  }
]

export const navLinks = [
  {
    id: "#home",
    title: "Home",
  },
  {
    id: "#enroll",
    title: "Enroll",
  },
  {
    id: "#search",
    title: "Search",
  },
  {
    id: "login",
    title: "Log-In",
  },
];

export const features = [
  {
    id: "feature-1",
    icon: star,
    title: "Seamless",
    content:
      "Seamlessly Integrate your Business here",
  },
  {
    id: "feature-2",
    icon: star,
    title: "Fast Booking",
    content:
      "Just send your customers your link or qr code then we'll have you booked in no time.",
  },
  {
    id: "feature-3",
    icon: star,
    title: "Lorem Ipsum",
    content:
      "chuchuchu",
  },
];

export const footerLinks = [
  {
    title: "Sampl1e",
    links: [
      {
        name: "Content",
        link: "https://www.sample.com/content/",
      },
      {
        name: "How to Book",
        link: "https://www.sample.com/how-it-works/",
      },
      {
        name: "Explore",
        link: "https://www.sample.com/explore/",
      },
      {
        name: "Terms & Services",
        link: "https://www.sample.com/terms-and-services/",
      },
    ],
  },
  {
    title: "Sample2",
    links: [
      {
        name: "Sample1",
        link: "https://www.sample.com",
      },
      {
        name: "Sample2",
        link: "https://www.sample.com",
      },
      {
        name: "Sample3",
        link: "https://www.sample.com",
      },
    ],
  },
  {
    title: "Sample3",
    links: [
      {
        name: "Sample1",
        link: "https://www.sample.com",
      },
      {
        name: "Sample2",
        link: "https://www.sample.com",
      },
    ],
  },
];

export const socialMedia = [
  {
    id: "social-media-1",
    icon: instagram,
    link: "https://www.instagram.com/",
  },
  {
    id: "social-media-2",
    icon: facebook,
    link: "https://www.facebook.com/",
  },
  {
    id: "social-media-3",
    icon: twitter,
    link: "https://www.twitter.com/",
  },
  {
    id: "social-media-4",
    icon: linkedin,
    link: "https://www.linkedin.com/",
  },
];
