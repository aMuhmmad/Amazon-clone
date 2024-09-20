import { Swiper, SwiperSlide } from "swiper/react";
import { Autoplay, Navigation } from "swiper/modules";

import "swiper/css";
import "swiper/css/navigation";
import { Link } from "react-router-dom";
import axios from "axios";
import { useEffect, useState } from "react";
import { callAPI } from "../utils/CallApi";

export const CarouselProduct = () => {

    const [products, setProducts] = useState(null);

    const getSearchResults = () => {

        const category = "Books";

        callAPI(`Products?category=${category}`)
            .then((searchResults) => {
                const categoryResults = searchResults;
                setProducts(categoryResults)
            })

    }

    useEffect(() => {
        getSearchResults();
    }, [])

    return (
        <div className="bg-white m-3">
            <div className="text-2xl font-semibold p-3">
                Best Sellers
            </div>
            <Swiper
                slidesPerView={5}
                spaceBetween={10}
                navigation={true}
                modules={[Navigation]}
            >
                {
                    products && products.slice(0,10).map((product,i) => (
                        <SwiperSlide key={i}>
                            <Link to={`/product/${product.id}`}>
                                <img className="w-[145px] h-[220px]" src={`${product.image}`} />
                            </Link>
                        </SwiperSlide>
                    ))
                }
            </Swiper>
        </div>
    )
}
