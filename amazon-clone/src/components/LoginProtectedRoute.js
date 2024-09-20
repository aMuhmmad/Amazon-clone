import { useEffect } from 'react';
import { useSelector } from 'react-redux';
import { Outlet, useNavigate } from 'react-router-dom';

export const LoginProtectedRoute = () => {
    const user = useSelector((state) => state.user.user);

    const navigate = useNavigate();

    useEffect(() => {
        if (user) {
            navigate("/");
        }
    }, [user])


    return (
        <Outlet />
    );
}
