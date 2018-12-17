declare module Server.Dtos {
	interface ProductResource extends ProductRecord {
		category: string;
		supplier: string;
	}
}
