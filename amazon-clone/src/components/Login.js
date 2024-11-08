import React, { useState } from 'react';
import './Login.css'
import { Link, useNavigate } from "react-router-dom";
import { useDispatch } from 'react-redux';
import { assignUser } from '../redux/userSlice';
import { userLogin, userRegister } from '../utils/CallApi';

export const Login = () => {

    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const navigate = useNavigate();
    const dispatch = useDispatch();

    const login = (e) => {
        e.preventDefault();

        userLogin({ email, password })
            .then((res) => {
                dispatch(assignUser(res.data))
                navigate('/');
            })

            .catch((e) => console.log(e.message));
    };

    const register = (e) => {
        e.preventDefault();

        userRegister({ email, password })
            .then((res) => {
                navigate('/');
            })
            .catch((e) => console.log(e.message));
    };


    return (
        <div className='login'>
            <Link to='/'>
                <img
                    className="login__logo"
                    src='https://upload.wikimedia.org/wikipedia/commons/thumb/a/a9/Amazon_logo.svg/1024px-Amazon_logo.svg.png'
                />
            </Link>

            <div className='login__container'>
                <h1>Sign-in</h1>

                <form>
                    <h5>E-mail</h5>
                    <input type='text' className='border' value={email} onChange={e => setEmail(e.target.value)} />

                    <h5>Password</h5>
                    <input type='password' className='border' value={password} onChange={e => setPassword(e.target.value)} />

                    <button onClick={login} type='submit' className='login__signInButton'>Sign In</button>
                </form>

                <p>
                    By signing-in you agree to the AMAZON FAKE CLONE Conditions of Use & Sale. Please
                    see our Privacy Notice, our Cookies Notice and our Interest-Based Ads Notice.
                </p>

                <button onClick={register} className='login__registerButton'>Create your Amazon Account</button>
            </div>
        </div>
    )
}
