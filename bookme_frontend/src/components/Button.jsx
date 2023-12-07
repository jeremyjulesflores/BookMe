import React from "react";
import { useNavigate } from "react-router-dom";

const Button = ({ styles, text, link }) => {
  const navigate = useNavigate();

  const handleClick = () => {
    // Navigate to the specified link
    navigate(link);
  };

  return (
    <button
      type="button"
      className={`py-4 px-6 font-poppins font-medium text-[18px] text-primary rounded-[10px] outline-none ${styles}`}
      onClick={handleClick}
    >
      {text}
    </button>
  );
};

export default Button;
