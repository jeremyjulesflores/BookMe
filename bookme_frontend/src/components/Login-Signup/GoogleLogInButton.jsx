import React from 'react'

const GoogleLogInButton = () => {
  return (
    // Has dark mode - implement later
    <button className="px-4 py-2 border flex gap-2 border-slate-200  rounded-lg text-black hover:border-slate-400 hover:text-slate-900  hover:shadow transition duration-150">
        <img className="w-6 h-6" src="https://www.svgrepo.com/show/475656/google-color.svg" loading="lazy" alt="google logo"/>
        <span>Login with Google</span>
    </button>
  )
}

export default GoogleLogInButton