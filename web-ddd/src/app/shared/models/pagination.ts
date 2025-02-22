import { ICatalogItem } from "./catalog-item";

export interface IPagination {
    totalItems: number;
    catalogItems: ICatalogItem[];
    pageSize: number;
    pageNumber: number;
}

export class Pagination implements IPagination {
    totalItems!: number;
    catalogItems: ICatalogItem[] = [];
    pageSize!: number;
    pageNumber!: number;
}