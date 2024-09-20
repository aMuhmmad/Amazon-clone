import { BrowserRouter, Route, Routes } from "react-router-dom";
import { CheckoutPage, HomePage, ProductPage, SearchResultsPage } from "./pages";
import { Login, NavBar } from "./components";
import { useDispatch, useSelector } from "react-redux";
import { useEffect } from "react";
import { assignUser } from "./redux/userSlice";
import { checkUser } from "./utils/CallApi";
import { LoginProtectedRoute, ProtectedRoute } from "./components/LoginProtectedRoute";


const App = () => {
  const dispatch = useDispatch();



  useEffect(() => {
    checkUser()
      .then(user => {
        if (user) {
          dispatch(assignUser(user));
        }
        else {
          console.log(user);
        }
      });
  }, [dispatch]);

  return (
    <BrowserRouter>
      <NavBar />
      <Routes>
        <Route exact path="/" element={<HomePage />} />
        <Route path="/search" element={<SearchResultsPage />} />
        <Route path="/product/:id" element={<ProductPage />} />
        <Route path="/checkout" element={<CheckoutPage />} />
        <Route element={<LoginProtectedRoute />}>
          <Route path="/login" element={<Login />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
