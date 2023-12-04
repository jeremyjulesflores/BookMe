import { BrowserRouter as Router,Route, Routes } from "react-router-dom";
import Home from "./Home"
import LoginPage from "./pages/LoginPage";
import SignUpPage from "./pages/SignUpPage";

const App = () => (
    <Router>
      <Routes>
        <Route path ='/' element = {<Home/>}/>
        <Route path ="/login" element = {<LoginPage/>}/>
        <Route path ="/signup" element = {<SignUpPage/>}/>
      </Routes>
    </Router>

);

export default App;
