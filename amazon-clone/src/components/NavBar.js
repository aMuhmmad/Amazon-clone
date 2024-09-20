import { ShoppingCartIcon } from "@heroicons/react/24/outline";
import { Search } from "./Search";
import { Link, useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { userLogout } from "../utils/CallApi";
import { assignUser } from "../redux/userSlice";

export const NavBar = () => {

    const cart = useSelector((state) => state.cart.productsNumber);
    const user = useSelector((state) => state.user.user);

    const dispatch = useDispatch();
    const navigate = useNavigate();

    const logout = () => {

        userLogout()
            .then((res) => {
                dispatch(assignUser(null));
                navigate('/');
            })

            .catch((e) => console.log(e.message));
    };


    return (
        <header className='min-w-[1000px]'>
            <div className='flex bg-amazonclone text-white h-[60px]'>

                <div className='flex items-center m-4'>
                    <Link to='/'>
                        <img className='h-[35px] w-[100px] m-2' src='../images/amazon.png' />
                    </Link>
                    <div className='px-4'>
                        <div className='text-xs xl:text-sm'>Deliver to</div>
                        <div className='text-xs xl:text-base font-bold'>Country</div>
                    </div>
                </div>

                <div className="flex grow relative items-center">
                    <Search />
                </div>

                <div className='flex items-center m-4'>
                    <Link to='/login'>
                        <div className='px-4'>
                            <div className='text-xs xl:text-sm'>Hello, {user ? user.email : "sign in"}</div>
                            <div className='text-xs xl:text-base font-bold'>Accounts & Lists</div>
                        </div>
                    </Link>
                    <div className='px-4'>
                        {user && <button onClick={() => logout()} className='text-xs xl:text-base font-bold'>SignOut</button>}
                    </div>
                    <Link to='/checkout'>
                        <div className='flex px-3'>
                            <ShoppingCartIcon className="h-[48px]" />
                            <div className="relative">
                                <div className="absolute right-[9px] font-bold m-2 text-orange-400">
                                    {user ? cart : 0}
                                </div>
                            </div>
                            <div className="mt-7 text-xs xl:text-sm font-bold">
                                Cart
                            </div>
                        </div>
                    </Link>
                </div>
            </div>
            <div className="flex bg-amazonclone-light_blue text-white space-x-3 text-xs xl:text-sm p-2 pl-6" >
                <div>Today's Deals</div>
                <div>Customer Service</div>
                <div>Registry</div>
                <div>Gift Cards</div>
                <div>Sell</div>
            </div>
        </header>
    )
}
