import { MagnifyingGlassIcon } from '@heroicons/react/24/outline'
import { useEffect, useState } from 'react'
import { createSearchParams, useNavigate } from 'react-router-dom';

import axios from 'axios';

export const Search = () => {

    const [suggestions, setSuggestions] = useState(null);
    const [searchTerm, setSearchTerm] = useState("");
    const [category, setCategory] = useState("All");
    const navigate = useNavigate();

    const handleSubmit = (e) => {
        e.preventDefault();

        navigate({
            pathname: "search",
            search: `${
                createSearchParams({
                category: `${category}`,
                searchTerm: `${searchTerm}`
            })}`
        })

        setSearchTerm("");
        setCategory("All");
    };

    const getSuggestions = () => {
        axios.get(`../data/suggestions.json`)
            .then((suggestionResults) => {
                setSuggestions(suggestionResults.data);
            })
    };

    useEffect(() => {
        getSuggestions();
    }, []);

    return (
        <div className='w-[100%]'>
            <div className='flex items-center h-10 bg-amazonclone-yellow rounded'>
                <select
                    className='p-2 bg-gray-300 text-black border text-xs xl:text-sm'
                    onChange={(e) => setCategory(e.target.value)}
                >
                    <option>All</option>
                    <option>Books</option>
                    <option>Deals</option>
                    <option>Amazon</option>
                    <option>Fashion</option>
                    <option>Computers</option>
                    <option>Home</option>
                    <option>Mobiles</option>
                </select>
                <input
                    className='flex grow items-center h-[100%] rounded-l text-black'
                    type='text'
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                />
                <button
                    className='w-[45px]'
                    onClick={handleSubmit}
                >
                    <MagnifyingGlassIcon className='h-[27px] m-auto stroke-slate-900' />
                </button>
            </div>
            {suggestions &&
                <div className='bg-white text-black w-full z-40 absolute'>
                    {
                        suggestions.filter((suggestion) => {
                            const currentSearchTerm = searchTerm.toLowerCase();
                            const title = suggestion.title.toLowerCase();
                            return (
                                currentSearchTerm &&
                                title.startsWith(currentSearchTerm)
                            )
                        })
                            .slice(0, 10)
                            .map((suggestion) => (
                                <div key={suggestion.id} onClick={() => setSearchTerm(suggestion.title)}>
                                    {suggestion.title}
                                </div>
                            ))
                    }
                </div>
            }
        </div>
    )
}
