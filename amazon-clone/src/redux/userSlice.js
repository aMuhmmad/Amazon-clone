import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    user: null,
}

export const userSlice = createSlice({
    name: "user",
    initialState,
    reducers: {
        assignUser: (state, action) => {
            state.user = action.payload;
        }
    }
});


export const { assignUser } = userSlice.actions;
export const userReducer = userSlice.reducer;