import { Genre } from '../models/genre'
import { Cast } from '../models/cast'

export interface MovieDetails {
    id: number;
    title: string;
    posterUrl: string;
    backdropUrl: string;
    rating: number;
    overview: string;
    tagline: string;
    budget: number;
    revenue: number;
    imdbUrl: string;
    tmdbUrl: string;
    runTime: number;
    price: number;
    releaseDate: Date;
    genres: Genre[];
    casts: Cast[];
}