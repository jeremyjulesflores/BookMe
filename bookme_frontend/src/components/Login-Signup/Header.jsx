import {Link} from 'react-router-dom';
import {logo  } from "../../assets";
export default function Header({
    heading,
    paragraph,
    linkName,
    linkUrl="#",
    paragraph2,
    linkName2,
    linkUrl2='#'
}){
    return(
        <div className="mb-10">
            <div className="flex justify-center">
                <img 
                    alt=""
                    className="h-10 w-25"
                    src={logo}/>
            </div>
            <h2 className="mt-6 text-center text-3xl font-extrabold text-gray-900">
                {heading}
            </h2>
            <p className="text-center text-sm text-gray-600 mt-5">
            {paragraph} {' '}
            <Link to={linkUrl} className="font-medium text-purple-600 hover:text-purple-500">
                {linkName}
            </Link>
            </p>
            <p className="text-center text-sm text-gray-600 ">
            {paragraph2} {' '}
            <Link to={linkUrl2} className="font-medium text-purple-600 hover:text-purple-500">
                {linkName2}
            </Link>
            </p>
        </div>
    )
}