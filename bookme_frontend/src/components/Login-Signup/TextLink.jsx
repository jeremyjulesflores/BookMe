import React from 'react';
import { Link } from 'react-router-dom';
import { textLinkFields } from '../../constants';

const TextLink = ({ page }) => {
  // Find the details for the specified page
  const linkDetails = textLinkFields.find((field) => field.page === page);

  // Check if details are found
  if (!linkDetails) {
    console.error(`Details not found for page: ${page}`);
    return null; // You can return an appropriate fallback or handle the case
  }

  const { paragraph, linkName, linkUrl } = linkDetails.details;

  return (
    <p className="text-center text-sm text-gray-600 mt-5">
      {paragraph}{' '}
      <Link to={linkUrl} className="font-medium text-purple-600 hover:text-purple-500">
        {linkName}
      </Link>
    </p>
  );
};

export default TextLink;
