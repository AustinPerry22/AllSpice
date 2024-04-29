export class Favorite{
    constructor(data) {
        // this is the recipe Id
        this.id = data.id
        this.accountId = data.accountId
        this.favoriteId = data.favoriteId
        this.category = data.category
        this.img = data.img
        this.instructions = data.instructions
        this.title = data.title
    }
}