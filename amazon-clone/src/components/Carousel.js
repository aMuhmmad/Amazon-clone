import { Swiper, SwiperSlide } from "swiper/react";
import { Autoplay, Navigation } from "swiper/modules";

import "swiper/css";
import "swiper/css/navigation";

export const Carousel = () => {
    return (
        <div className="h-[600px] bg-white">
            <Swiper
                loop={true}
                spaceBetween={0}
                navigation={true}
                modules={[Navigation, Autoplay]}
                autoplay={{
                    delay: 4500
                }}
                className="h-[50%]"
            >
                <SwiperSlide>
                    <img src="https://res.cloudinary.com/ding7zvwj/image/upload/t_1920x768/v1704064414/amazon-image/1348517_in_prime_2_pd_3000x1200_Eng._CB663273097_.jpg_ddeezv.png" />
                </SwiperSlide>
                <SwiperSlide>
                    <img src="https://res.cloudinary.com/ding7zvwj/image/upload/t_1920x768/v1704092089/amazon-image/71Ie3JXGfVL._SX3000__kgat5b.jpg" />
                </SwiperSlide>
                <SwiperSlide>
                    <img src="https://res.cloudinary.com/ding7zvwj/image/upload/t_1920x768/v1704092088/amazon-image/61CiqVTRBEL._SX3000__keb9oi.jpg" />
                </SwiperSlide>

            </Swiper>
            <div className="h-[50%] bg-gradient-to-b from-stone-200" />
        </div>
    )
}
