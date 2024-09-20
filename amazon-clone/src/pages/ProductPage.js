import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom"
import { useDispatch, useSelector } from "react-redux";

import { callAPI } from "../utils/CallApi";
import { ProductBadge, ProductDetails, ProductRatings } from "../components";
import { GB_CURRENCY } from "../utils/constants";
import { addToCart } from "../redux/cartSlice";
import getSymbolFromCurrency from "currency-symbol-map";
import axios from "axios";

export const ProductPage = () => {

  const { id } = useParams();
  const [product, setProduct] = useState(null);
  const [quantity, setQuantity] = useState("1")
  const dispatch = useDispatch();
  const user = useSelector((state) => state.user.user);

  const getProduct = async () => {
    const product = await callAPI(`Products/${id}`);
    setProduct(product);
  }

  useEffect(() => {
    getProduct();
  }, []);


  const addQuantityToProduct = () => {
    console.log(product);
    setProduct(product.quantity = quantity);
    return product;
  }

  console.log(user);


  if (!product?.name) {
    return (
      <h1>
        Loading Product ...
      </h1>
    )
  }

  return (product &&
    <div className="h-screen bg-amazonclone-background">
      <div className="min-w-[1000px] max-w-[1500px] m-auto p-4">
        <div className="grid grid-cols-10 gap-2">
          {/* Left */}
          <div className="col-span-3 p-8 rounded bg-white m-auto">
            <img src={`${product.image}`} />
          </div>

          {/* Middle */}
          <div className="col-span-4 p-4 rounded bg-white ">


            <div className='text-xl xl:text-2xl font-medium mb-1'>{product.name}</div>
            <div className='text-sm xl:text-base mb-1'>
              <ProductRatings avgRating={product.averageRating} ratings={product.ratings} />
            </div>
            <hr></hr>
            <div>
              <div className="my-2">Shipping starts at <strong>{getSymbolFromCurrency('EGP')} {product.shippingCost}</strong>. No Cost Shipping available</div>
              <div className="text-base xl:text-lg text-green-700 font-semibold mt-1">In Stock</div>
              <div className="my-2">Sold by <strong>{product.soldby}</strong> and Fulfilled by Amazon.</div>
            </div>
            <div className='text-sm xl:text-base mb-1'>by <span className='text-blue-500'>{product.brand}</span></div>

            <div className='text-xs xl:text-sm font-bold mb-1'>{product.attribute}</div>
            <div><ProductBadge badge={product.badge} /></div>
            <div className="text-base xl:text-lg mt-3">
              <div className="text-2xl mt-1">About this item</div>
              {product.description}
            </div>

          </div>

          {/* Right */}
          <div className="col-span-2 p-4 rounded bg-white">

            <div className="text-xl xl:text-2xl text-red-700 text-right font-semibold">{GB_CURRENCY.format(product.price)}</div>
            <div className="text-base xl:text-lg text-gray-500 text-right font-semibold">RRP: <span className="line-through">{GB_CURRENCY.format(product.oldPrice)}</span></div>
            <div className="text-sm xl:text-base text-blue-500 font-semibold mt-3">FREE Returns</div>
            <div className="text-sm xl:text-base text-blue-500 font-semibold mt-1">FREE Delivery</div>
            <div className="text-base xl:text-lg mt-1">
              Quantity:
              <select
                className="p-2 bg-white border rounded-md focus:border-indigo-600"
                onChange={(e) => setQuantity(e.target.value)}
              >
                <option>1</option>
                <option>2</option>
                <option>3</option>
              </select>
            </div>

            <Link to={'/checkout'}>
              <button
                className="bg-yellow-400 w-full p-3 text-xs xl:text-sm rounded hover:bg-yellow-500 mt-3"
                onClick={() => dispatch(addToCart(addQuantityToProduct()))}
                disabled = {user ? false : true}
              >
                Add to Cart
              </button>
            </Link>

          </div>
        </div>
      </div>
    </div>
  )
}
